<?php 
include 'database.php';



try {
        $conn = new PDO("mysql:host=$servername;dbname=$dbname", $username, $password);
        $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
       
      }
      catch(PDOException $e){
            echo "Error: " . $e->getMessage();
      }

      $username = $_POST['usernamePost'];
      $password = $_POST['passwordPost'];

       $stmt = $conn->query("SELECT * FROM player WHERE name = '".$username."'");
         $stmt->execute();
            
      $result = $stmt->fetchAll();
      $total_records = count($result);
       
           
      if ($total_records != 0)
      {
      	echo "Failed";
      }   else {
      	 $stmt = $conn->prepare(" INSERT INTO player (name,password) values ('".$username."','".$password."') ");
      	$stmt->execute();
      	echo "OK";
      } 
	


     

?>