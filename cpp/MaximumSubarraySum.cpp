#include <bits/stdc++.h>
using namespace std;
//< > split_string()
vector<string> split_string(string);
//(< >,)
long maximumSum(vector<long> vec, long m) {
    //< >
    set<long> ans;
    long global_max, prev_sum, prev_mod, lmax;
    //< >::
    set<long>::iterator itr;
    //= = []%
    global_max = prev_mod = vec[0] % m;
    //= []
    prev_sum = vec[0];
    //.insert()
    ans.insert(prev_mod);
    //for < .size()
    for (unsigned int i=1; i<vec.size(); i++) {
        //+= []
        prev_sum += vec[i];
        prev_mod = prev_sum % m;
        //if = .upper_bound() != .end()
        if ((itr = ans.upper_bound(prev_mod)) != ans.end()) {
            //= (- * +) %
            lmax = (prev_mod - *itr + m) % m;
        }
        else
            //=
            lmax = prev_mod;
        //.insert()
        ans.insert(prev_mod);
        //=max()
        global_max = max(global_max,lmax); 
    }
    //return
    return global_max;
}
int main()
{
    ofstream fout(getenv("OUTPUT_PATH"));

    int q;
    cin >> q;
    cin.ignore(numeric_limits<streamsize>::max(), '\n');

    for (int q_itr = 0; q_itr < q; q_itr++) {
        string nm_temp;
        getline(cin, nm_temp);

        vector<string> nm = split_string(nm_temp);

        int n = stoi(nm[0]);

        long m = stol(nm[1]);

        string a_temp_temp;
        getline(cin, a_temp_temp);

        vector<string> a_temp = split_string(a_temp_temp);

        vector<long> a(n);

        for (int i = 0; i < n; i++) {
            long a_item = stol(a_temp[i]);

            a[i] = a_item;
        }

        long result = maximumSum(a, m);

        fout << result << "\n";
    }

    fout.close();

    return 0;
}
//< >
vector<string> split_string(string input_string) {
    //:: = unique(.begin(),.end(),[](&,&))
    string::iterator new_end = unique(input_string.begin(), input_string.end(), [] (const char &x, const char &y) {
        //return
        return x == y and x == ' ';
    });
    //.erase(,.end())
    input_string.erase(new_end, input_string.end());
    //while [.length()-1)] ==
    while (input_string[input_string.length() - 1] == ' ') {
        //.pop_back()
        input_string.pop_back();
    }
    //< >
    vector<string> splits;
    //=
    char delimiter = ' ';
    size_t i = 0;
    //= .find()
    size_t pos = input_string.find(delimiter);
    //while (!= ::)
    while (pos != string::npos) {
        //.push_back(.substr(,-))
        splits.push_back(input_string.substr(i, pos - i));
        //= +
        i = pos + 1;
        //= .find(,)
        pos = input_string.find(delimiter, i);
    }
    //.push_back(.substr(,min(,.length())- +))
    splits.push_back(input_string.substr(i, min(pos, input_string.length()) - i + 1));
    //return
    return splits;
}