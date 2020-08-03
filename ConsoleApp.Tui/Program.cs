using System;
using Terminal.Gui;

namespace ConsoleApp.Tui
{
    class Program
    {
        public static Action NewFile { get; private set; }

        static void Main(string[] args)
        {
            Application.Init();
            var top = Application.Top;

            var win = new Window("MyApp")
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };
            top.Add(win);

            var menu = new MenuBar(new MenuBarItem[] {
                new MenuBarItem ("_File", new MenuItem [] {
                    new MenuItem ("_New", "Creates new file", NewFile),
                    new MenuItem ("_Close", "", () => Close()),
                    new MenuItem ("_Quit", "", () => { if (Quit()) top.Running = false; })
                }),
                new MenuBarItem ("_Edit", new MenuItem [] {
                    new MenuItem ("_Copy", "", null),
                    new MenuItem ("C_ut", "", null),
                    new MenuItem ("_Paste", "", null)
                })
            });
            top.Add(menu);

            var login = new Label("Login: ") { X = 3, Y = 2 };
            var password = new Label("Password: ")
            {
                X = Pos.Left(login),
                Y = Pos.Top(login) + 1
            };
            var loginText = new TextField("")
            {
                X = Pos.Right(password),
                Y = Pos.Top(login),
                Width = 40
            };
            var passText = new TextField("")
            {
                Secret = true,
                X = Pos.Left(loginText),
                Y = Pos.Top(password),
                Width = Dim.Width(loginText)
            };

            win.Add(
                login, password, loginText, passText,

                new CheckBox(3, 6, "Remember me"),
                new RadioGroup(3, 8, new[] { "_Personal", "_Company" }),
                new Button(3, 14, "Ok"),
                new Button(10, 14, "Cancel"),
                new Label(3, 18, "Press F9 or ESC plus 9 to activate the menubar"));


            Application.Run();

        }

        private static void Close()
        {
            throw new NotImplementedException();
        }

        private static bool Quit()
        {
            throw new NotImplementedException();
        }
    }
}
