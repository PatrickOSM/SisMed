using System.Collections.Generic;
using Newtonsoft.Json;
using SisMed.Util.Class;
using SisMed.Util.Enums;

namespace SisMed.Util
{
    public class Toast
    {
        #region Variáveis
        public string type { get; set; }
        public string message { get; set; }
        public string title { get; set; }
        public string positionClass { get; set; }
        public int fadeIn { get; set; }
        public int fadeOut { get; set; }
        public int timeOut { get; set; }
        public int extendedTimeOut { get; set; }
        public bool debug { get; set; }
        public DisplayType DType
        {
            set
            {
                this.positionClass = GetPosicao(value);
            }
        }
        #endregion

        #region Construtor
        public Toast(MessageType type, string message, DisplayType dtype = DisplayType.TopRight)
        {
            this.type = type.ToString();
            this.message = message;
            this.DType = dtype;
            this.fadeIn = 300;
            this.fadeOut = 1000;
            this.timeOut = 5000;
            this.extendedTimeOut = 1000;
            this.debug = false;
        }
        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Deserializa todas as mensagens Toastr
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static List<Toast> DeserializarTodos(string json)
        {
            return JsonConvert.DeserializeObject<List<Toast>>(json);
        }

        /// <summary>
        /// Serializa todas as mensagens Toastr
        /// </summary>
        /// <param name="toasts"></param>
        /// <returns></returns>
        public static string SerializarTodos(List<Toast> toasts)
        {
            return JsonConvert.SerializeObject(toasts);
        }
        #endregion

        #region Métodos Privados
        /// <summary>
        /// Obtêm o atributo positionClass da mensagem Toastr
        /// </summary>
        /// <param name="dtype"></param>
        /// <returns></returns>
        private string GetPosicao(DisplayType dtype)
        {
            string posicao = string.Empty;

            switch (dtype)
            {
                case DisplayType.TopLeft:
                    posicao = ToastrProperties.TopLeft;
                    break;
                case DisplayType.TopFull:
                    posicao = ToastrProperties.TopFull;
                    break;
                case DisplayType.BottomRight:
                    posicao = ToastrProperties.BottomRight;
                    break;
                case DisplayType.BottomLeft:
                    posicao = ToastrProperties.BottomLeft;
                    break;
                case DisplayType.BottomFull:
                    posicao = ToastrProperties.BottomFull;
                    break;
                case DisplayType.TopRight:
                default:
                    posicao = ToastrProperties.TopRight;
                    break;
            };

            return posicao;
        }
        #endregion
    }
}
