using Exam.Admin.Models;
using Exam.Common;
using Exam.Core.Utils;
using Exam.Domain;
using Exam.Domain.Model;
using Exam.IService;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Exam.Admin.Controllers
{
    /// <summary>
    /// 角色菜单
    /// </summary>
    public class SysGroupMenuController : BaseController
    {
        // GET: SysGroupMenu
        private readonly ISysGroupMenuService _sysGroupMenuService;
        private readonly ISysMenuService _sysMenuService;
        public SysGroupMenuController(ISysGroupMenuService sysGroupMenuService, ISysMenuService sysMenuService)
        {
            _sysGroupMenuService = sysGroupMenuService;
            _sysMenuService = sysMenuService;
        }

        public ActionResult Edit(SysGroupMenuVM _sysRoleMenuVM)
        {
            _sysRoleMenuVM.SysMenus = _sysMenuService.GetAll().Where(p => p.Type == _sysRoleMenuVM.GroupType && p.IsEnable == (int)EnumHelp.EnabledEnum.有效).ToList();
            return View(_sysRoleMenuVM);
        }
        /// <summary>
        /// 添加、修改
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Edit(int groupId = 0, int[] menuId = null)
        {
            try
            {
                _sysGroupMenuService.DeleteByGroupId(groupId);
                for (int i = 0; i < menuId.Length; i++)
                {
                    var model = new SysGroupMenu()
                    {
                        SysGroupId = groupId,
                        SysMenuId = menuId[i], 
                        CTime = DateTime.Now,
                        UTime = DateTime.Now,
                    };
                    _sysGroupMenuService.Insert(model);
                }
                return Json(new { Status = Successed.Ok }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Status = Successed.Error }, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// 获取分组相关菜单
        /// </summary>
        /// <param name="groupId">分组Id</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetGroupMenus(int groupId = 0)
        {
            var list = _sysGroupMenuService.GetAll().Where(p=>p.SysGroupId == groupId).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}