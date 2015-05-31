<?php
$_POST["username"]="root";
$_POST["password"]="";
$_POST["query"]="select * from tb_kartu";

$link=mysqli_connect("127.0.0.1",$_POST["username"],$_POST["password"],"db_tcg") or die("Cannot connect to mysql server.");

//print '[{"one":"Hello", "two":"World"}]';
$result=mysqli_query($link,$_POST["query"]) or die("Error");
echo "["; //start array
$hasNextArray=1;
$isFirstArray=1;
while($row = mysqli_fetch_assoc($result) or $hasNextArray=0)
{
  if($hasNextArray and !$isFirstArray)
  {
	  echo ","; //Masih ada element selanjutnya, kasih koma yah.
  }
  
  echo '{'; // start relasi
  while ($atom=current($row)){
		
	  echo '"'.addslashes(key($row)).'"'; //key
	  
	  echo ':'; // pembatas key dengan value
	  
	  echo '"'.addslashes($atom).'"'; //value
	  
	  
	  if(next($row)!="")
	  {
		  echo ","; //masih ada lanjutan
	  }
  }
  echo '}'; // stop relasi
  $isFirstArray=0;
} 
echo "]"; //stop array
?>