
# Traffic Code Test

## Presentation

TrafficCodeTest is an exhibition project to show to employers my capabilities in C#/.Net. I use Entity Framework modelize the database from our models.

For the story, this idea come from a friend (owner of a driving school) who want to add quiz about traffic code in his new website in order to his clients (driving students) can improve their traffic code knowledge's. He is going to employ someone abroad to do it because it is cheaper. 

Thus, I have thought to how to do a basic version of this functinnality and that project is born.

## Overview

This project contain 3 principals areas:

- Teachers area
- Students area
- Connexion area

At First I will develop the Teachers area then the Students area and finally the Connxion area. 

#### Teachers area :

Each teacher can add new questions to the list of questions, edit questions and delete questions. This part is done by modifying  .Net Core auto-generated code. So, functionnalities are develped in contrellers.

Improvement : The next impovement is to do a dashbord follow student evolution.

#### Students area :

Student can start a test composed by a random mix of 40 questions about different part of the traffic code. To validate the test they have to get 35/40. For each question they have 20 secondes to answer then next question appear.

This part is done from scratch and I use a structure with a DAL (Data Access Layer) to implement students area functionalities. Also, I write a test code for each method of the DAL.

#### Connexion area :

This area is in purpose manage sign ups and logins. Also, to disable Sign up and Connexion to teachers area for students. 

