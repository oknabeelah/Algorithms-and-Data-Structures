Console.WriteLine("Algorithms and Data Structures - Lab 9");

// Comment out these lines to run the experiment.
 List<Double> data = ReadWriteFile.readData("C:\\Users\\Admin\\OneDrive - Sheffield Hallam University\\week9 ads tutorial\\ADSLab9\\dataset.csv"); // FOR WINDOWS, PLEASE GET YOUR FILE PATH RIGHT!
 HillClimbing hc = new HillClimbing(data);

hc.runHC(1000);


/*Scales scales1 = new Scales();
Scales scales2 = new Scales();
scales1.printSol();
scales2.printSol();
scales2.copySolution(scales1.solution);
scales2.printSol();

scales2 = hc.smallChange(scales2, 3);
scales2.printSol();*/
//Console.WriteLine(scales.fitness);
