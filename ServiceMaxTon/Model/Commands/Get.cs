using ServiceMaxTon.Data;
using ServiceMaxTon.Model.DataBase;

using Telegram.Bot;
using Telegram.Bot.Types;

namespace ServiceMaxTon.Model.Commands
{
    public class Get : Command
    {
        public override string Name => "Данные";

        public override string Description => throw new System.NotImplementedException();

        public override async void Execute(Message message, TelegramBotClient client)
        {
            AppDbContext db = new AppDbContext();
            //CompletedWork cw = new CompletedWork();
            string[] str = message.Text.Split();
            string strOut ="";
            if(str.Length==2)
            {
               switch(str[1])
                {
                    case "выполнено":
                        foreach (CompletedWork cw in db.CompletedWork)
                        {

                            strOut += $"ID:{cw.id}\n" +
                                $"Дата:{cw.Date.ToString("d")}\n" +
                                $"Процент:{cw.Transparency}\n" +
                                $"Длинна:{cw.Lenght}\n" +
                                $"Стоимость:{cw.Cash}р\n" +
                                $"Производитель:{cw.Manufacturer}\n"+
                                $"\n";

                        }
                        break;
                    case "расходы":
                        foreach (Expenses expenses in db.Expenses)
                        {

                            strOut += $"ID:{expenses.id}\n" +
                                $"Дата:{expenses.Date.ToString("d")}\n" +
                                $"Затраты:{expenses.CashExpenses}р\n" +
                                $"Комментарий:{expenses.Name}\n" +
                                $"\n";

                        }
                        break;
                    case "пленка":
                        foreach (Material m  in db.Material)
                        {

                            strOut += $"ID:{m.id}\n" +
                                $"Дата:{m.Date.ToString("d")}\n" +
                                $"Стоимость:{m.cost}р\n" +
                                $"Производитель:{m.manufacturer}\n" +
                                $"Процент: { m.Transparency}\n" +
                                $"Длинна: { m.lenght}\n" +
                                $"\n";

                        }
                        break;
                    default:
                        strOut = $"Команда {str[1]} не определена";
                        break;
                }
            }
            else
            {
                strOut = "Не верный формат запроса";
            }

            if(strOut=="")
            {
                strOut = $"В таблице {str[1]} отсутствуют данные";
            }

            await client.SendTextMessageAsync(message.Chat.Id, strOut);
        }
    }
}
