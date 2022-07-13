object Solution {
    //define, parameters, output
  def drawTriangles(n: Int): Unit = {
    //define, parameters, output
    def cut(field: IndexedSeq[IndexedSeq[Char]], n: Int, width: Int, height: Int): IndexedSeq[IndexedSeq[Char]] = {
      //optimization
      @scala.annotation.tailrec
      //define, parameters, output
      def innerCut(n: Int, x: Int, y: Int, left: Int, top: Int, width: Int, height: Int): Boolean = {
        //set to calculate
        def halfWidth = width / 2
        def halfHeight = height / 2
        //if &&
        n > 0 && (
            //>= && <= || if else %*4
          (y >= halfHeight && math.abs(halfWidth - x) <= height - 1 - y) ||
            innerCut(n - 1, (x + (if (y < halfHeight) (halfWidth + 1) / 2 else 0)) % (halfWidth + 1), y % halfHeight, left % (halfWidth + 1), top % halfHeight, halfWidth, halfHeight)
          )
      }
      //.indices.map pass on
      field.indices.map(y => {
        //.indices.map pass on
        field(y).indices.map(x => {
            //if innerCut() else
          if (innerCut(n, x, y, 0, 0, width, height)) zero else field(y)(x)
        })
      })
    }
    //cut()
    cut(init, n, width, height)
    println(cut(init, n, width, height).map(_.mkString("")).mkString("\n"))
  }
  //define, output
  def init: IndexedSeq[IndexedSeq[Char]] = {
    //until, .map, pass on
    (0 until height).map(y => {
        //until, .map, pass on
      (0 until width).map(x => {
        //if >= else
        if (math.min(x, width - 1 - x) >= (height - 1 - y)) one else zero
      })
    })
  }

  //set to
  def width = 63
  def height = 32
  def zero = '_'
  def one = '1'

  def main(args: Array[String]) {
    drawTriangles(readInt())
  }
  //define
  def readInt(): Int = scala.io.StdIn.readInt()
}