# PayrollConsole
This tool is a usefull tool to calculate the payroll slip for many employees by having just a few parameters.

#Features
- *Multiples format files*: JSON and CSV are allowed, 
but everything loaded in the application domain which implements IFormater interface could be used instead
- *Dynamic Formulas*: you could update or modify the formulas due to new goverment tax formula
- *Multithreading*: not worry about having lots of records, you could increase the amount of running thread to make the process run faster.
- *Injection Dependency*: everything is replaceable, you don't need to worry about changing some tool, just implement the desired tool 

#Run the application
```
*Usage*:
	Data\PayrollConsole.exe -i input.csv -if csv -o output.csv -of csv -t taxrates.csv -tf csv
*Parameters*:
	-i Input File Path
	-if Input File Format: currently supported json or csv
	-o Output file Path
	-of Output File Format: currently supported json or csv
	-t Tax File Path
	-tf Tax File Format: currently supported json or csv

*Settings*:
The settings files are inside the file PayrollConsole.exe.config
*Keys*:
	ThreadCount: amount of thread that would run in parallel mode
	GrossIncomeFormula: formula used to calculate the monthly gross salary
	IncomeTaxFormula: formula used to calculate the monthly income tax
	NetIncomeFormula: formula used to calculate how much the employee will earn in hand
	SuperFormula: formula to determine the super on a monthly basis
```

*Formula Parameters*: you could use the input and tax files to execute the formula, every field of this input files could be overriten in the formula by closing them between [], example: [AnnualIncome] (nevermind uppper or lower case, the application is case insentitive)

#Develop the application
If you want to contribute, this is the general architechture of the application:

The application uses AutoFac Injection Dependency Container, so you don't need to worry about resolving anything from your code, just use as much Interfaces as 
tools do you need and then register it into #Configuration.cs. 

*Interfaces*: every interface is inside this folder, consider use an interface before making any class, so you could always use the container to get the intance of the class. Don't worry about building instances, Autofac will inject all dependency (just make sure to register everything you need before instance anything).

*Implementation*: then you could go ahead and implement any of the interfaces that you made in the previous step. Note that you don't need to share everything not related with your application inside, just use your interface wrapping, then when a tool need to be changed, just implement another tool with the same interfacce and voila!

*Entities*: every exchange DTO should be an entity to be better understanding of the code.

*Commnand Line Parser*: there is a command line parser to avoid making difficult to parse the input, just add those parameters that you need in the Configuration.cs

*Nuget Package Manager*: for those who are familiar with this kind of tools such as npm or maven, for .NET nuget is the default package manager, so you just need to restore the dependencies using nuget.

*Formater*: the solution is intented to be able to have another formatter just by copping the new assembly into the folder, you just need to implement the interface IFormatHelper and put your compiled DLL inside the folder, and you are ready to use this new formatter (BETA TESTING!)


#Assumptions
- I first wanted to make a MVC site but then I realized that this could be much more than the excercise, so I decided to make a command line for this.
- I know that this program could be an over enginnering piece since the excercise is really simple but I wanted to show some modern development techniques as the same time, this is an assumption, because otherwise you could think about me as an Engineer who wants to make things complicated, and I love an IBM phrase that prays something like "KISS" (Keep It Simple Stup....)
- You may note that I'm not doing nothing complex in the excercise, just downloaded a few tools that made complex thing for me (for example to evaluate string as Formulas), I think that is the best way to do things (by not re-making the wheel), I must use what people is good and make what make my bussines need, I understood the excercise like this but if you wanted to me doing things like low level, I could make it so (but I'd hate you guys!).


