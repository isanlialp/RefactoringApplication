# RefactoringApplication
Replication Package : This is a replication package for the paper Developing a Prim-based Algorithm to Prioritize Refactoring  Techniques to Reduce Software Energy Consumption
-------------------------------------------------------

Abstract : There exist several refactoring techniques
to improve software quality. Some of them
aim to reduce the energy consumption of software.
However, the order of applied refactoring techniques
is crucial to the success rate. This study aims at producing
optimal refactoring order for the given source
code. A C# application is developed in the context
of the study. That application extracts static code
metrics and decides what sort of refactoring techniques
are compatible with the chosen source code.
A refactoring order is then produced with a primbased
graph algorithm utilizing the metrics showing
the complexity of the source code. Lastly, original
and refactored source code, which is generated with
the order revealed from the algorithm, are compared
in terms of energy consumption. If a source code
is exposed to multiple-refactoring alterations, the order
of them is crucial to reduce energy consumption.
Otherwise, applying refactoring to source code


Getting Started
-------------------------------------------------------
These instructions will allow you to install the developed tool on your local machine.


Prerequisites
-------------------------------------------------------
You need The following software and packages to install and run the developed tool:

Software:

Visual Studio (required minimum version 2017)
R (3.6.2 version)
LocMetrics (for installation from github:  )
JHawk ( any recent version, not required professional versions)

Package:

Microsoft Code Analysis
Microsoft Code Analysis Metrics
Microsoft Office Interop Excel
EPPlus


How to use Application 
---------------------------------

1) Open Visual Studio as Administrator
2) Go to Application directory   
3) Run the application 
4) Click BROWSE Button  (for getting an object-oriented source code from a specific location)
6) Select project class from ListBox control named Entire File/ Folder Path
7) Go to "Refactoring Techniques" (menu item)
                
                     Refactoring Techniques 
                            |                                 
                            |               (submenu items)
                            |------->R1: Encapsulate Field
                            |------->R2: Simplify Nested Loop
                            |------->R3: Inline Temp
                            |------->R4: Introduce Explaining Variable
                            |------->R5: Replace Magic Number with Symbolic Constant
                            |------->R6: Consolidate Duplicate Conditional Fragments
                            |------->R7: Hide Method
             
8) Select the refactoring technique you want to apply 
9) After entering the required information in the form that opens, APPLY the technique
10) Save the refactored code via Button control named Save in the main form 
      (At the same time Log File of the class is Saved )
11) To save the metric values of the selected project class, 
CREATE the excel file with the help of the button named Excel in the main form opened.
12) Go to "Software Metrics" (menu item)

                      Software Metrics 
                            |
                            |                 (submenu items)
                            |------->M1: Lines of Code (LOC)
                            |------->M2: Statements (SLOC-L)
                            |------->M3: Cyclomatic Complexity (MvG)
                            |------->M4: Operand and Operator Count per Class
                            |------->M5: Class Coupling
                            |------->M6: Maintainability Index
                            |------->M7: Depth of Inheritance Tree
                            |------->M8: Statements per Method
                            |------->M9: Calls per Method
                            |------->M10: Methods per Class

13) Select and Apply software metrics in order
14) Save metric values with the Save Metric button controls on the selected open metric forms 
15) Go to Step 8 until ALL Refactoring Techniques have been applied individually.
16) Go to "Detecting Optimal Order”  (menu item)

                      Detecting Optimal Order
                            |
                            |                 (submenu items)
                            |------->Finding the Code Refactoring Technique Applied Using Log
                            |------->Finding the Optimal Order of Refactoring Techniques

17) Select Finding the Code Refactoring Technique Applied Using Log submenu item 
18) Open Log File of the class via Open Log Data button control
19) Click Applied Ref-Tech buton 
20) Save Refactoring Technique Applied via Save button 
21) Click Adjacency Matrix button (The adjacency matrix  extracted from the nodes is held at R script files)
22) Save R Script via Save button 
23) Select Finding the Optimal Order of Refactoring Techniques
24) Click Open R Path (the physical paths of R scripts are loaded to ListBox)
25) Select Path and Click Run R Script button control
26) Click Optimal Order (optimal order of refactoring techniques is generated via R script)
27) An illustration that gives the optimal order of refactoring techniques via R Plot Window button control
28) To estimate the energy consumption, Go to "Estimate Energy Consumption (EC)" (menu item) 

                      Estimate Energy Consumption
                            |
                            |                 (submenu items)
                            |------->Open and Run Intel Power Gadget
                            |------->Take EC Data
                            |------->Close Intel Power Gadget

29) Select the Open and Run Intel Power Gadget sub menu (run the source code before selecting this menu)
30) After a specific period, the Intel Power Gadget is is stopped (periodic time is optional)
31) Take results via Take EC Data (The results are saved as a CSV file)
32) Close Intel Power Gadget.

Projects have to be coded with an object-oriented programming language (C# or Java).
