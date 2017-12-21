 
using System;
using System.Linq;
using System.Web.Mvc;

namespace Exam.Admin.Controllers
{
    /// <summary>
    /// 角色菜单
    /// </summary>
    public class SysRoleMenuController : BaseController
    {
        // GET: SysRoleMenu
        private readonly ISysRoleMenuService _sysRoleMenuService;
        private readonly ISysMenuService _sysMenuService;
        public SysRoleMenuController(ISysRoleMenuService sysRoleMenuService, ISysMenuService sysMenuService)
        {
            _sysRoleMenuService = sysRoleMenuService;
            _sysMenuService = sysMenuService;
        }

        public ActionResult Edit(SysRoleMenuVM _sysRoleMenuVM)
        {
            _sysRoleMenuVM.SysMenuDTO = _sysMenuService.AllMenu().Where(p => p.Type == _sysRoleMenuVM.RoleType).ToList();
            return View(_sysRoleMenuVM);
        }
        /// <summary>
        /// 添加、修改
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Edit(int roleId = 0, int[] menuId = null)
        {
            try
            {
                _sysRoleMenuService.RoleIdByDelete(roleId);
                for (int i = 0; i < menuId.Length; i++)
                {
                    var model = new SysRoleMenu()
                    {
                        Role_Id = roleId,
                        Menu_Id = menuId[i],
                        CreatePersonId = Loginer.AccountId,
                        CreateTime = DateTime.Now
                    };
                    _sysRoleMenuService.Insert(model);
                }
                return Json(new { Status = Successed.Ok }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Status = Successed.Error }, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// 获取角色相关菜单
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetRoleMenus(int roleId = 0)
        {
            var list = _sysRoleMenuService.GetRoleIdByMenus(roleId);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}