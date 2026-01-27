VAR questText = "Talk to Qinyi"
->Kristen1
=== Kristen1 ===
Hello! #name Kristen #camera 2
So! This is the B-Hive, Vanier's very own community space. #playSad true
Cool! #name Player
so quick question i gotta ask when you come in here— #name Kristen
do you care about the lives of minorities? 
*[I guess??]
Well, buckle up, cause several minorities are currently in danger! #name Kristen
I'm gonna fucking kill myself. #name Yellow #camera 6 2
Our community's been in shambles ever since Marya's dissapearence.#name Kristen #camera 2 2
We're currently very understaffed for today's Art Hive event and I can only do so much!
It's breaking Qinyi's heart!
I'm so sorry everyone I'm sure the supplies will get here any moment now... #name Ms.Qinyi #camera 7 2
Yeahhh. It's messed up #name Kristen #camera 2 2
So you feel bad enough yet? #playSad false
-> afterChoice
*[Yes]
Well, buckle up, cause several minorities are currently in danger! #name Kristen
I'm gonna fucking kill myself #name Yellow #camera 6 2
Our community's been in shambles ever since Marya's dissapearence. #name Kristen #camera 2 2
We're currently very understaffed for today's Art Hive event and I can only do so much
It's breaking Qinyi's heart!
I'm so sorry everyone I'm sure the supplies will get here any moment now... #name Ms.Qinyi #camera 7 2
Yeahhh. It's messed up #name Kristen #camera 2 2
Do you feel bad enough yet? #playSad false
-> afterChoice
=== afterChoice ===
Don't worry the tasks I ask of you are gonna be really easy, and will appear in the top left corner of your screeen. #camera 0 2
It'll be fun! #music yes #kristen away #quest {questText}
->END