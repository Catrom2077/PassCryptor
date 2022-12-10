using PassCryptor.ConsoleApp.BackEnd;

MenuController menuController = new();

menuController.DrawBanner();
menuController.DrawMenu();

while(true)
{
    menuController.HandleInput();

    if (menuController.IsExit) break;
}