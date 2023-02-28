// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.WriteLine("# of processors = " + Environment.ProcessorCount);

Thread th1 = new Thread(threadFunction1);
Thread th2 = new Thread(threadFunction2);
Thread th3 = new Thread(threadFunction3);
th1.Name = "thread1";
th2.Name = "thread2";
th3.Name = "thread3";
th1.Start();
th2.Start();
th3.Start();

for(int i = 0; i < 10; i++){
    Console.WriteLine("Main function thread " + i.ToString());
    Thread.Sleep(1000);
}

static void threadFunction1(){
    for(int i = 0; i < 10; i++){
        Console.WriteLine("1st thread function " + i.ToString());
        Thread.Sleep(1000);
    }
}

static void threadFunction2(){
    for(int i = 0; i < 10; i++){
        Console.WriteLine("2nd thread function " + i.ToString());
        Thread.Sleep(1000);
    }
}

static void threadFunction3(){
    for(int i = 0; i < 10; i++){
        Console.WriteLine("3rd thread function " + i.ToString());
        Thread.Sleep(1000);
    }
}
