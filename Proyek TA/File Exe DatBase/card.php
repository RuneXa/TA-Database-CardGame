<?php

$link=mysqli_connect("127.0.0.1","root","","db_tcg") or die("Cannot connect to mysql server.");

//print '[{"one":"Hello", "two":"World"}]';
if($_POST["multi"])
{
	mysqli_multi_query($link,$_POST["query"]) or die("Error");
}else
{
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
	  while (($atom=current($row)) !=NULL){
			
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
}
?>