<?php header('Content-Type: text/html; charset=utf-8'); ?> 
<!DOCTYPE html>
<html>
	<head>
			<title> PHP - DB</title>
	</head>	
	
<form action="index.php" method="post">
<p> Введите номер: <input type="text" name="number" value = ""></p>
<p> Введите фамилию: <input type="text" name="surname" value = ""></p>
<p> Введите имя: <input type="text" name="name" value = ""></p>
<p><input type="submit" name="write" value="Записать"></p>
<p><input type="submit" name="selectall" value="Вывести все записи таблицы БД"></p>
<p> Найти по фамилии: <input type="text" name="fsurname" value = ""></p>
<p><input type="submit" name="search" value="Поиск"></p>
<p> Удалить по номеру: <input type="text" name="del" value = ""></p>
<p><input type="submit" name="delete" value="Удалить"></p>
<p> Изменить по номеру: <input type="text" name="change" value = ""></p>
<p><input type="submit" name="changebutton" value="Изменить"></p>
</form>

<?php

$link = mysqli_connect("localhost", "root", '') or die ("Could not connect to MySQL server!"); // устанавливаем соединение с mySQL server
mysqli_select_db ($link, "newdb") or die ("Could not select database!"); // указываем с какой БД планируется работать

if (isset($_POST['write']))
{
//записываем данные из полей формы в БД
$sql = "INSERT INTO newtable (N, Surname, Name) VALUES ('{$_POST["number"]}', '{$_POST["surname"]}', '{$_POST["name"]}')"; 

if (mysqli_query($link, $sql)) 
     {
      echo "Новая запись добавлена!". "<br />";
     } 
     else 
     {
       echo "Error: " . $sql . "<br>" . mysqli_error($link);
     }
mysqli_close($link); // закрывается соединение с mySQL server
    }

//запрос вывода всех данных из таблицы

if (isset($_POST['selectall'])) 
{
    $query1 = mysqli_query($link, "SELECT * FROM newtable");
    echo ("N " . "Surname " . "Name " . "<br />");
    while($row=mysqli_fetch_array($query1))
    {
        echo $row['N'],' ', $row['Surname'],' ', $row['Name'],' '. "<br />"; // вывод массива данных из столбцов таблицы
    }
}

//запрос поиск по логину
if(isset($_POST['search']))
{   
 $surname = $_POST['fsurname'];  
 $query1 = mysqli_query($link, "SELECT * FROM `newtable` WHERE `Surname`='$surname'");
 echo ("N " . "Фамилия " . "Имя " . "<br />");
 
  while($row=mysqli_fetch_array($query1))
    {
    echo $row['N'],' ', $row['Surname'],' ', $row['Name'],' '. "<br />"; // вывод массива данных из столбцов таблицы
  }  
}

//запрос удаление по номеру
if(isset($_POST['delete']))
{   
 $number = $_POST['del'];  
 $query1 = mysqli_query($link, "DELETE FROM `newtable` WHERE `N`='$number'");
 echo ("Запись удалена!");
}

if (isset($_POST['changebutton'])) 
  {
    $change = $_POST['change'];  
    $query1 = mysqli_query($link,"UPDATE `newtable` SET `N`='{$_POST["number"]}',`Surname`='{$_POST["surname"]}',
    `Name`='{$_POST["name"]}' WHERE `N`='$change'");    
    echo ("Запись изменена!");
  }

  
?>
