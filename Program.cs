using APBD2.Classes;

var testL = new LiquidConteiner(300, 200, 400, 3000, true);
testL.Load(2200);
testL.Empty();
testL.Load(1400);
Conteiner testL2 = new LiquidConteiner(200, 100, 300, 1000, false);
testL2.Load(905);
testL2.Empty();
testL2.Load(800);
Console.WriteLine(testL.ToString());
Console.WriteLine(testL2.ToString());


var testG = new GasConteiner(300, 250, 300, 500, 10);
testG.Load(490);
testG.Empty();
testG.Load(490);
Console.WriteLine(testG.ToString());

var testC = new CoolContainer(250, 400, 500, 300, "Bananas", 10);
testC.Load(200,13,"Bananas");
testC.Load(150, 9 , "Fish");
testC.Empty();
testC.Load(299,13,"Bananas");
Console.WriteLine(testC.ToString());



var ship1 = new Ship(100,5000,3);
var ship2 = new Ship(150,3000,2);

var list = new List<Conteiner>();
list.Add(testL);
list.Add(testL2);

Console.WriteLine("dodawanie kontenerów");
ship1.AddContainers(list);
ship1.AddContainer(testG);
ship2.AddContainer(testC);
ship1.ShowContainers();
ship2.ShowContainers();


Console.WriteLine("usuwanie kontenera");
ship1.RemoveContainer("KON-L-1");
ship1.ShowContainers();


Console.WriteLine("przeniesienie kontenera");

ship1.TransferContainer(ship2, "KON-L-0");
ship1.ShowContainers();
ship2.ShowContainers();


Console.WriteLine("zastąpowanie kontenera");

var testC1 = new CoolContainer(500, 500, 500, 500, "Fish", 3);
testC1.Load(400,5,"Fish");

ship1.ReplaceContainer("KON-G-0", testC1);
ship1.ShowContainers();


