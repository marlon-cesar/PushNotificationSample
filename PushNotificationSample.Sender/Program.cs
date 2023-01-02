// See https://aka.ms/new-console-template for more information
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

if (!File.Exists("private_key.json"))
{
    Console.WriteLine("Arquivo: 'private_key.json' está faltando.\nVocê precisa fazer o downloads das credenciais do projeto no FireBase, copiar para o projeto e configurar o build action");
    return;
}

FirebaseApp.Create(new AppOptions
{
    Credential = GoogleCredential.FromFile("private_key.json"),
});

while (true)
{

    Console.WriteLine("\n\t\tENVIE SUA MENSAGEM\n");

    var registrationToken = "ADD_TOKEN";
    var topicName = "mytopic";

    Console.WriteLine("Digite o título da notificação:");
    var title = Console.ReadLine();
    Console.WriteLine("Digite a mensagem da notificação:");
    var message = Console.ReadLine();

    var notificationMessage = new Message
    {
        Data = new Dictionary<string, string>
    {
        {"Data", "Teste"}
    },
        //Token = registrationToken,
        Topic = topicName,
        Notification = new Notification
        {
            Title = title,
            Body = message
        }
    };


    var response = FirebaseMessaging.DefaultInstance.SendAsync(notificationMessage).Result;


    Console.WriteLine($"Notificação enviada!\n\tResponse: {response}");

    Console.ReadLine();
}