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
    /// Answer菜单
    /// </summary>
    public class AnswerController : BaseController
    {
        // GET: Answer
        private readonly IAnswerService _AnswerService;
        public AnswerController(IAnswerService AnswerService)
        {
            _AnswerService = AnswerService;
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        public ActionResult Edit(AnswerVM vm)
        {
            vm.Answer = _AnswerService.GetById(vm.Id) ?? new Answer();
              
            return View(vm);
        }

        /// <summary>
        /// 添加、修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Edit(Answer model)
        {
            try
            {
                if (model.AnswerId > 0)
                {
                    var entity = _AnswerService.GetById(model.AnswerId);
                    //修改 
                    entity.AnswerId = model.AnswerId;
                    entity.Title = model.Title;
                    entity.IsCorrect = model.IsCorrect; 
                    _AnswerService.Update(entity);
                }
                else
                {
                    if (_AnswerService.IsExistName(model.Title))
                        return Json(new { Status = Successed.Repeat }, JsonRequestBehavior.AllowGet);
                     
                    _AnswerService.Insert(model);
                }
                return Json(new { Status = Successed.Ok }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Status = Successed.Error }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Delete(int id = 0)
        {
            try
            {
                var entity = _AnswerService.GetById(id);

                if (entity == null)
                {
                    return Json(new { Status = Successed.Empty }, JsonRequestBehavior.AllowGet);
                }

                _AnswerService.Delete(entity);

                return Json(new { Status = Successed.Ok }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Status = Successed.Error }, JsonRequestBehavior.AllowGet);
            }
        }
    
    }
}