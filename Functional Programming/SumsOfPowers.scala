import java.util.Scanner

object Solution {
    //define, parameters x, listNumbers, output, if <, else if ==, else
  def SumsOfPowers(x: Int, listNumbers: List[Int]): Int = if (x < 0) 0 else if (x == 0) 1 else {
    //match
    listNumbers match {
        //case pass on
      case Nil => 0
      //case variable pass on recursion
      case c :: cs => SumsOfPowers(x - c, cs) + SumsOfPowers(x, cs)
    }
  }
  //define
  def main(args: Array[String]): Unit = {
    //set to create new
    val sc = new Scanner(System.in)
    //set to
    val x = sc.nextInt
    val n = sc.nextInt
    //.close
    sc.close()
    //set to, .from, .map, i pass to, .pow, .takeWhile, .map, .toList
    val listNumbers = LazyList.from(1).map(i => BigInt(i).pow(n)).takeWhile(_ <= x).map(_.toInt).toList
    println(SumsOfPowers(x, listNumbers))
  }
}