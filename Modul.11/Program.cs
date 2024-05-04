using System;
using System.Xml.Xsl;

namespace TelegramBot
{
    class Bot//класс инкапсулирует (заключает в себя) логику обработки входящих запросов
    {
        ///<summary>
        ///объект, отвеающий за отправку сообщений клиенту
        ///</summary>
        private IBotClient _telegramClient;

        public Bot (IBotClient telegramClient)
        {
            _telegramClient = telegramClient;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)//метод регистрирующий обработки событий
        {
            _telegramClient.OnMessage += HandleMessage;
            _telegramClient.OnMessage += HandleButtonClick;

            Console.WriteLine("bot started");
        }

        ///<summary>
        ///Обработчик входящих текстовых сообщений
        /// </summary>
        private async Task HandleMessage(object sender, MessageEventArgs e)
        {
            //бот получил входящее сообщение пользователя
            var messageText = e.Message.Text;

            //бот отправляет ответ
            _telegramClient.SendTextMessage(e.ChatId, "Ответ на сообщение пользователя");
        }

        ///<summary>
        ///Обработчик нажатий на кнопки
        ///</summary>
        private async Task HandleButtonClick(object sender, MessageEventArgs e)
        {

        }
    }
}
