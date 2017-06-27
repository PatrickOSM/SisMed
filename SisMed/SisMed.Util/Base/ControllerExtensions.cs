using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SisMed.Util.Class;

namespace SisMed.Util.Base
{
    public static class ControllerExtensions
    {
        /// <summary>
        /// Mostra uma mensagem do tipo Toastr para o usuário
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="mensagemToast"></param>
        /// <param name="mostrarAposRedirecionar"></param>
        public static void MostrarMensagem(this Controller controller, Toast mensagemToast, bool mostrarAposRedirecionar = false)
        {
            try
            {
                if (mensagemToast != null)
                {
                    var allToast = new List<Toast>();

                    //Recebe as mensagens existentes no Temp ou Response baseado na opção de redirecionamento
                    var mensagensJson = mostrarAposRedirecionar ? controller.TempData[ToastrProperties.MessagesKey]?.ToString() 
                        : controller.Response.Headers[ToastrProperties.MessagesKey];

                    // Deserialize the JSON into the toast list
                    if (!string.IsNullOrEmpty(mensagensJson))
                    {
                        try
                        {
                            allToast = Toast.DeserializarTodos((string) mensagensJson);
                        }
                        catch
                        {
                            //Ignorado
                        }
                    }

                    // Adiciona um novo Toastr a lista
                    allToast.Add(mensagemToast);

                    // Serializa a lista
                    string jsonSerializado = Toast.SerializarTodos(allToast);
                    
                    if (!string.IsNullOrEmpty(jsonSerializado))
                    {
                        if (mostrarAposRedirecionar)
                        {
                            controller.TempData[ToastrProperties.MessagesKey] = jsonSerializado;
                        }
                        else
                        {
                            controller.Response.Headers[ToastrProperties.MessagesKey] = jsonSerializado;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Ignorado
            }
        }
    }
}
