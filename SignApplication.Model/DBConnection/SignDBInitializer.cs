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
                new SystemList(){ ID = 3, Title = "Content Element Type" },
                new SystemList(){ ID = 4, Title = "Event Type" },
                new SystemList(){ ID = 5, Title = "Uploaded Files Group" }
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

                new SystemListValue(){ ID = 9, SystemListID = 3, Title = "Подпись" },

                new SystemListValue(){ ID = 10, SystemListID = 4, Title = "Запись добавлена" },
                new SystemListValue(){ ID = 11, SystemListID = 4, Title = "Запись изменена" },
                new SystemListValue(){ ID = 12, SystemListID = 4, Title = "Запись удалена" },
                new SystemListValue(){ ID = 13, SystemListID = 4, Title = "Запрос отправлен" },

                new SystemListValue(){ ID = 14, SystemListID = 5, Title = "Документ" }
                
            };
            context.SystemListValues.AddRange(listValue);

            User user = new User() { ID = 1, LastName = "Rebrov" };
            context.Users.Add(user);
            user = new User() { ID = 2, LastName = "Voronin",EMail = "voronin@gmail.com",Password = "qwerty"};
            context.Users.Add(user);
            //UploadedFile upl = new UploadedFile() { ID = 1, GroupID = 14 };
            //context.UploadedFiles.Add(upl);
            //Document doc = new Document() { ID = 1, Name = "WorkContract", UserID = 1, StateID = 1, UploadedFileID = 1};
            //context.Documents.Add(doc);

            base.Seed(context);
        }

    }
}
