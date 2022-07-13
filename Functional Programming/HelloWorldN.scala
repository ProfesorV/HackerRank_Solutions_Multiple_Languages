object Solution extends App {
    //define, parameter
    def f(n: Int): Unit = {
        //until, foreach
        (0 until n).foreach(_ => println("Hello World"))
        }
  var n = scala.io.StdIn.readInt
  f(n)
}
