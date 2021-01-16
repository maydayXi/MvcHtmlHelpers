using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcHtmlHelpers.Models;

namespace MvcHtmlHelpers.Controllers
{
    public class EmployeesController : Controller
    {
        // 初始化 Entity Framework 的 Context 環境
        // 用來做資料庫存取
        private CmsModel db = new CmsModel();

        #region Read
        // GET: Employees
        public ActionResult Index()
        {
            // 讀取 Employees 資料表，並轉成 List 集合
            var emps = db.Employees.ToList();
            string user = emps.Where(e => e.Department.Equals("人事部"))
                .Select(e => e.Name).FirstOrDefault();

            ViewBag.User = user;
            // 將集合回傳前端檢視
            return View(emps);
        }

        /// <summary>
        /// 員工明細資料查詢
        /// </summary>
        /// <param name="id"> 員工編號 </param>
        /// <returns> 員工明細檢視 </returns>
        public ActionResult Details(int? id)
        {
            // 無傳入員工編號
            if (id.Equals(null))
                // 回傳 404
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            // Find 方法只適用 List<T> 型別
            Employee emp = db.Employees.Find(id);

            // 找不到員工
            if (emp.Equals(null))
                // 回傳 400
                return HttpNotFound();

            return View(emp);
        }
        #endregion

        #region Create
        /// <summary>
        /// GET：新增資料檢視
        /// </summary>
        /// <returns> 新增資料檢視 </returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST：Create 寫入資料
        /// </summary>
        /// <param name="employee"> 員工資料模型 </param>
        /// <returns> 員工清單檢視 / 新增檢視 </returns>
        [HttpPost]                      // 使用 Http Post 請求
        [ValidateAntiForgeryToken]      // 防止 CSRF 跨網站請求偽造攻擊
        public ActionResult Create(
            // Bind 是用來指定要異動的欄位，以防止 over-posting 攻擊
            [Bind(Include = "Id, Name, Mobile, Email, Department, Title")] 
            Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(employee);
        }
        #endregion

        #region Update 
        /// <summary>
        /// GET：Edit
        /// </summary>
        /// <param name="id"> 員工編號 </param>
        /// <returns> 編輯檢視 </returns>
        public ActionResult Edit(int? id)
        {
            // 防呆機制，無傳入員工編號，回傳 404
            if (id.Equals(null))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Employee employee = db.Employees.Find(id);

            // 找不到員工，回傳 400
            if (employee.Equals(null))
                return HttpNotFound();

            return View(employee);
        }

        /// <summary>
        /// POST：Edit 異動員工資料
        /// </summary>
        /// <param name="employee"> Employee Data Model Object </param>
        /// <returns> 編輯資料檢視 / 員工清單檢視 </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "Id, Name, Mobile, Email, Department, Title")]
            Employee employee)
        {
            // 用 ModelState 判斷資料是否通過驗證
            if (ModelState.IsValid)
            {
                // 將 employee 這個 Entity 狀態設為 Modified
                db.Entry(employee).State = EntityState.Modified;
                // SaveChanges 執行時，會向 SQL Server 發出 Update 陳述式
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(employee);
        }
        #endregion

        #region Delete
        /// <summary>
        /// GET：Delete
        /// </summary>
        /// <param name="id"> 員工編號 </param>
        /// <returns> 刪除檢視 </returns>
        public ActionResult Delete(int? id)
        {
            if (id.Equals(null))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var employee = db.Employees.Find(id);

            if (employee.Equals(null))
                return HttpNotFound();

            return View(employee);
        }

        /// <summary>
        /// POST：刪除員工資料
        /// </summary>
        /// <param name="id"> 員工編號 </param>
        /// <returns> 首頁 </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Employee employee = db.Employees.Find(id);

            db.Employees.Remove(employee);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        #endregion
    }
}