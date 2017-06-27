using System.Web.Mvc;
using SisMed.Util.Enums;

namespace SisMed.Util.Base
{
    /// <summary>
    /// Controle Base da aplicação
    /// </summary>
    public abstract class BaseController : Controller
    {

        #region Sobrescrita
        /// <summary>
        /// Lida com qualquer exceção não tratada que ocorra no controlador
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnException(ExceptionContext filterContext)
        {
            this.MostrarMensagem(new Toast(MessageType.warning, "Ocorreu uma falha inesperada, favor entrar em contato com o administrador do sistema."), true);

            var exception = filterContext.Exception;
            filterContext.ExceptionHandled = true;

            var result = this.View("Error", new HandleErrorInfo(exception,
            filterContext.RouteData.Values["controller"].ToString(),
            filterContext.RouteData.Values["action"].ToString()));

            filterContext.Result = result;
            base.OnException(filterContext);
        }
        #endregion
    }
}
