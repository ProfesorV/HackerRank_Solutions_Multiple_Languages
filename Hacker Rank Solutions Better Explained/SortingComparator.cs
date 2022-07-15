class Checker{
public:
  	//Player, Player
    static int comparator(Player pPlayera, Player pPlayerb)  {
      //if <
	    if(pPlayera.score < pPlayerb.score) return -1;
        //if >
        if(pPlayera.score > pPlayerb.score) return 1;
        //if <
        if(pPlayera.name < pPlayerb.name) return 1;
        //if >
        if(pPlayera.name > pPlayerb.name) return -1;
        //return
        return 0;
    }
};

