class Checker{
public:
  	//Player, Player
    static int comparator(Player a, Player b)  {
      //if condition (Player < Player)
	    if(a.score < b.score) return -1;
        //if condition (Player > Player)
        if(a.score > b.score) return 1;
        //if condition (Player < Player)
        if(a.name < b.name) return 1;
        //if condition (Player > Player)
        if(a.name > b.name) return -1;
        //return
        return 0;
    }
};

