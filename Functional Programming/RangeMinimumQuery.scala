import java.util.Scanner

//class, parameters nodeValue
case class Node(var nodeValue: Int)
//class, parameters, treeLen
class SegmentTree(treeLen: Int) {
    //create as
  val treeNodes: Array[Node] = Array.fill[Node](4 * treeLen)(Node(Int.MaxValue))
  //define, parameters index, nodeValue, v, left, right, output
  def addNode(index: Int, nodeValue: Int, v: Int = 1, left: Int = 0, right: Int = treeLen - 1): Unit = {
    //if !=
    if (left != right) {
        //set to
      val middle = (left + right) >> 1
      //if <=
      if (index <= middle) addNode(index, nodeValue, 2 * v, left, middle)
      //else
      else addNode(index, nodeValue, 2 * v + 1, middle + 1, right)
      //set to
      treeNodes(v).nodeValue = combine(treeNodes(2 * v).nodeValue, treeNodes(2 * v + 1).nodeValue)
    }
    else {
        //set to
      val node = treeNodes(v)
      //set to
      node.nodeValue = nodeValue
    }
  }
  //define, parameters leftLimit, rightLimit, v, left, right, output
  def treeQuery(leftLimit: Int, rightLimit: Int, v: Int = 1, left: Int = 0, right: Int = treeLen - 1): Int = {
    //if == &&
    if (leftLimit == left && rightLimit == right) {
        //set to
      val node = treeNodes(v)
      node.nodeValue
    }
    //else
    else {
        //set to
      val middle = (left + right) >> 1
      //if <= recursion
      if (rightLimit <= middle) treeQuery(leftLimit, rightLimit, 2 * v, left, middle)
      //else if > recursion
      else if (leftLimit > middle) treeQuery(leftLimit, rightLimit, 2 * v + 1, middle + 1, right)
      //else
      else combine(
        treeQuery(leftLimit, middle, 2 * v, left, middle),
        treeQuery(middle + 1, rightLimit, 2 * v + 1, middle + 1, right)
      )
    }
  }
  //define, parameters leftValue, rightValue, output
  def combine(leftValue: Int, rightValue: Int): Int = math.min(leftValue, rightValue)
}

object Solution {
  def main(args: Array[String]): Unit = {
    val sc = new Scanner(System.in)

    val n = sc.nextInt
    val m = sc.nextInt
    val arr = (0 until n).map(_ => sc.nextInt)

    val tree = new SegmentTree(arr.length)
    arr.indices.foreach(i => tree.addNode(i, arr(i)))

    (0 until m).foreach(_ => {
      val left = sc.nextInt
      val right = sc.nextInt

      println(tree.treeQuery(left, right))
    })

    sc.close()
  }
}