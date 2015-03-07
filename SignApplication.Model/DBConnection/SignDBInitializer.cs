using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignApplication.Model.DBConnection
{
    public class SignDBInitializer : DropCreateDatabaseAlways<SignAppContext>
    {

        protected override void Seed(SignAppContext context)
        {
            IList<SystemList> list = new List<SystemList>()
            {
                new SystemList(){ ID = 1, Title = "Document State" },
                new SystemList(){ ID = 2, Title = "Request Status" },
                new SystemList(){ ID = 3, Title = "Event Type" },
                new SystemList(){ ID = 4, Title = "Uploaded Files Group" },
                new SystemList(){ ID = 5, Title = "Email Type"}
            };
            context.SystemLists.AddRange(list);

            IList<SystemListValue> listValue = new List<SystemListValue>()
            {
                new SystemListValue(){ ID = 1, SystemListID = 1, Title = "Загружен" },
                new SystemListValue(){ ID = 2, SystemListID = 1, Title = "Редактируется" },
                new SystemListValue(){ ID = 3, SystemListID = 1, Title = "Отправлен" },
                new SystemListValue(){ ID = 4, SystemListID = 1, Title = "Готов к отправке" },

                new SystemListValue(){ ID = 5, SystemListID = 2, Title = "Запрос отправлен" },
                new SystemListValue(){ ID = 6, SystemListID = 2, Title = "Запрос отменен" },
                new SystemListValue(){ ID = 7, SystemListID = 2, Title = "Документ просмотрен" },
                new SystemListValue(){ ID = 8, SystemListID = 2, Title = "Документ подписан" },

                new SystemListValue(){ ID = 9, SystemListID = 3, Title = "Запись добавлена" },
                new SystemListValue(){ ID = 10, SystemListID = 3, Title = "Запись изменена" },
                new SystemListValue(){ ID = 11, SystemListID = 3, Title = "Запись удалена" },
                new SystemListValue(){ ID = 12, SystemListID = 3, Title = "Запрос отправлен" },

                new SystemListValue(){ ID = 13, SystemListID = 4, Title = "Исходный документ" },
                new SystemListValue(){ ID = 14, SystemListID = 4, Title = "Страница документа" },
                new SystemListValue(){ ID = 15, SystemListID = 4, Title = "Страница документа в низком качестве" },
                new SystemListValue(){ ID = 16, SystemListID = 4, Title = "Подпись" },
                new SystemListValue(){ ID = 17, SystemListID = 4, Title = "Оканчательный документ" },

                new SystemListValue(){ ID = 18, SystemListID = 5, Title = "Регистрация" },
                new SystemListValue(){ ID = 19, SystemListID = 5, Title = "Запрос на подпись" },
                new SystemListValue(){ ID = 20, SystemListID = 5, Title = "Подписанный документ для подписавшегося" },
                new SystemListValue(){ ID = 21, SystemListID = 5, Title = "Подписанный документ для отправителя запроса" }
                
            };
            context.SystemListValues.AddRange(listValue);

            ContentType content = new ContentType()
            {
                ID = 1,
                Class = "glyphicon-pencil",
                DefaultHeight = 50,
                DefaultWidth = 110,
                IsDelete = false,
                DefaultValue = "элемент для подписи",
                Title = "Подпись"
            };
            context.ContentTypes.Add(content);
            content = new ContentType()
            {
                ID = 2,
                Class = "glyphicon-pencil",
                DefaultHeight = 50,
                DefaultWidth = 110,
                IsDelete = false,
                DefaultValue = "элемент для текста",
                Title = "Лейбл"
            };
            context.ContentTypes.Add(content);


            User user = new User() { ID = 1, LastName = "Rebrov" };
            context.Users.Add(user);
            user = new User() { ID = 2, LastName = "Voronin",EMail = "voronin@gmail.com",Password = "qwerty"};
            context.Users.Add(user);
            user = new User() { ID = 3, LastName = "Tomsky", EMail = "pavalandrey@gmail.com", Password = "qwerty" };
            context.Users.Add(user);

            Document doc = new Document() { ID = 1, Name = "Contract", UserID = 2, StateID = 1 };
            context.Documents.Add(doc);
            doc = new Document() { ID = 2, Name = "Gazprom Inc", UserID = 3, StateID = 1 };
            context.Documents.Add(doc);
            doc = new Document() { ID = 3, Name = "Solution", UserID = 2, StateID = 1 };
            context.Documents.Add(doc);
            doc = new Document() { ID = 4, Name = "Rosneft", UserID = 2, StateID = 1 };
            context.Documents.Add(doc);
            doc = new Document() { ID = 5, Name = "OT-Oil", UserID = 3, StateID = 1 };
            context.Documents.Add(doc);
            doc = new Document() { ID = 6, Name = "1 Billion COntract", UserID = 2, StateID = 1 };
            context.Documents.Add(doc);
            doc = new Document() { ID = 7, Name = "System", UserID = 2, StateID = 1 };
            context.Documents.Add(doc);
            doc = new Document() { ID = 8, Name = "TestDocument", UserID = 2, StateID = 1 };
            context.Documents.Add(doc);
            doc = new Document() { ID = 9, Name = "Hernya", UserID = 3, StateID = 1 };
            context.Documents.Add(doc);


            UploadedFile upl = new UploadedFile() { ID = 1, GroupID = 13, DocumentID = 1, UploadedDate = DateTime.Now, IsDelete = false, FileName = "415effee_b069_4d1b_a123_5878b1aa3d02.jpg", ContentType = "image/jpeg", UserID = 2 };
            context.UploadedFiles.Add(upl);
            upl = new UploadedFile() { ID = 2, GroupID = 13, DocumentID = 2, UploadedDate = DateTime.Now, IsDelete = false, FileName = "4255d518_e21f_46c8_8821_89d844b55d28.jpg", ContentType = "image/jpeg", UserID = 3 };
            context.UploadedFiles.Add(upl);
            upl = new UploadedFile() { ID = 3, GroupID = 13, DocumentID = 3, UploadedDate = DateTime.Today, IsDelete = false, FileName = "25afd6ca_0374_40a9_af63_05c4261fa1fc.jpg", ContentType = "image/jpeg", UserID = 2 };
            context.UploadedFiles.Add(upl);
            upl = new UploadedFile() { ID = 4, GroupID = 13, DocumentID = 4, UploadedDate = DateTime.Now, IsDelete = false, FileName = "774e9bb6_c0b2_4e33_b4fa_c20a6f807e27.jpg", ContentType = "image/jpeg", UserID = 2 };
            context.UploadedFiles.Add(upl);
            upl = new UploadedFile() { ID = 5, GroupID = 13, DocumentID = 5, UploadedDate = DateTime.Today, IsDelete = false, FileName = "3a211daa_fed6_46f7_8cdc_bc9d9e0181c4.jpg", ContentType = "image/jpeg", UserID = 3 };
            context.UploadedFiles.Add(upl);
            upl = new UploadedFile() { ID = 6, GroupID = 13, DocumentID = 6, UploadedDate = DateTime.Now, IsDelete = false, FileName = "34bcdadf_ec48_4ec0_89e9_1c7a29847c5f.jpg", ContentType = "image/jpeg", UserID = 2 };
            context.UploadedFiles.Add(upl);
            upl = new UploadedFile() { ID = 7, GroupID = 13, DocumentID = 7, UploadedDate = DateTime.Today, IsDelete = false, FileName = "3928d831_7436_4e5e_b939_561cf9532cda.pdf", ContentType = "application/pdf", UserID = 2 };
            context.UploadedFiles.Add(upl);
            upl = new UploadedFile() { ID = 8, GroupID = 13, DocumentID = 8, UploadedDate = DateTime.Now, IsDelete = false, FileName = "83fe48df_9a5b_44aa_801b_e380c7663f42.jpg", ContentType = "image/jpeg", UserID = 2 };
            context.UploadedFiles.Add(upl);
            upl = new UploadedFile() { ID = 9, GroupID = 13, DocumentID = 9, UploadedDate = DateTime.Today, IsDelete = false, FileName = "088a629a_d1f2_40b5_8e43_53aca77eb624.jpg", ContentType = "image/jpeg", UserID = 3 };
            context.UploadedFiles.Add(upl);

            EmailText emailText = new EmailText()
            {
                ID = 1,
                TypeID = 18,
                Subject = "Активация аккаунта",
                Body = "Активация аккаунта на РаспишитесьЗдесь! \n" +
                       "Вы успешно зарегистрировались на сервисе РаспишитесьЗдесь. \n" +
                       "Ваш логин: <%EMAIL%> \n" +
                       "Ваш пароль: **** (сохранен и надежно зашифрован) \n" +
                       "Для активации аккаунта перейдите по этой ссылке. \n" +
                       "Если по каким то причинам ссылка выше не работает, вставьте следующий адрес в сроку браузера: \n" +
                       "https://...... \n" +
                       "С уважением, \n" +
                       "команда РапишитесьЗдесь"
            };
            context.EmailTexts.Add(emailText);

            emailText = new EmailText()
            {
                ID = 2,
                TypeID = 19,
                Subject = "Запрос на подпись",
                Body = "<html><body><p>Здравствуйте, <%NAME%>!</p> \n" +
                    "<p><%SENDERNAME%> просит Вас подписать документ. \n" +
                    "<%LINK%> </p>\n" +
                    "<p>С уважением, \n" +
                    "команда РапишитесьЗдесь</p>" +
                    "</body></html>"
            };
            context.EmailTexts.Add(emailText);

            //emailText = new EmailText() { ID = 3, TypeID = 3, Text = "Отправка подписанного документа подписавшимся" };
            //context.EmailTexts.Add(emailText);
            //emailText = new EmailText() { ID = 4, TypeID = 4, Text = "Отправка подписанного документа отправителю заявки на подпись" };
            //context.EmailTexts.Add(emailText);

            base.Seed(context);
        }

    }
}
