object Solution {
    //define, parameters x, output, match
     def fibonacci(x:Int):Int = x match {
    //case pass to
    case 1 => 0
    case 2 => 1
    //case pass to repeat function
    case _ => fibonacci(x - 1) + fibonacci(x - 2)
  }
    def main(args: Array[String]) {
         /** This will handle the input and output**/
         println(fibonacci(readInt()))

    }
    //define, output
    def readInt(): Int = scala.io.StdIn.readInt()
}