<?php 
include 'database.php';

try {
        $conn = new PDO("mysql:host=$servername;dbname=$dbname", $username, $password);
        $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
       
       
      }
      catch(PDOException $e){
            echo "Error: " . $e->getMessage();
      }

      // $question_id =  "E1";
      //$question_id =  $_POST['questionPost'];
      $stmt = $conn->query("SELECT title_ID, title, choice1, choice2, choice3, choice4, correctAns FROM question "); //WHERE title_ID = '".$question_id."'
          $stmt->execute();
          $result = $stmt->fetchAll();

          $total_records = count($result);
       
           
      if ($total_records > 0){
          foreach($result as $readrow) {
      
        echo "title:".$readrow['title'].'|'; 
       echo "C1:".$readrow['choice1'].'|'; 
         echo "C2:".$readrow['choice2'].'|'; 
         echo "C3:".$readrow['choice3'].'|'; 
       echo "C4:".$readrow['choice4'].'|'; 
        echo "ans:".$readrow['correctAns'].'|'; 
        echo "TitleID:".$readrow['title_ID'].';'; 
      }
   }
?>