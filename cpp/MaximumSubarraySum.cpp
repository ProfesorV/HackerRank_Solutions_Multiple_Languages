#include <bits/stdc++.h>
using namespace std;
vector<string> split_string(string);
//vector<long>, long
long maximumSum(vector<long> vec, long m) {
    //set <long>
    set<long> ans;
    //long, long, long, long
    long global_max, prev_sum, prev_mod, lmax;
    //set<long>::iterator
    set<long>::iterator itr;
    //set to
    global_max = prev_mod = vec[0] % m;
    //set to
    prev_sum = vec[0];
    //apply function .insert()
    ans.insert(prev_mod);
    //for condition (int < vector<long>.size())
    for (unsigned int i=1; i<vec.size(); i++) {
        //augment by
        prev_sum += vec[i];
        //set to
        prev_mod = prev_sum % m;
        //if condition (= apply function .upper_bond()!= apply functiion .end())
        if ((itr = ans.upper_bound(prev_mod)) != ans.end()) {
            //set to calculate
            lmax = (prev_mod - *itr + m) % m;
        }
        else
            //set to
            lmax = prev_mod;
        //apply function .insert()
        ans.insert(prev_mod);
        //set to apply function max()
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
//string
vector<string> split_string(string input_string) {
    //set to apply function .begin(), apply function .end(), []()
    string::iterator new_end = unique(input_string.begin(), input_string.end(), [] (const char &x, const char &y) {
        //return
        return x == y and x == ' ';
    });
    //apply functi1on .erase
    input_string.erase(new_end, input_string.end());
    //while condition ()
    while (input_string[input_string.length() - 1] == ' ') {
        //apply function .pop_back
        input_string.pop_back();
    }
    //declare
    vector<string> splits;
    //set to
    char delimiter = ' ';
    size_t i = 0;
    //set to apply function .find()
    size_t pos = input_string.find(delimiter);
    //while condition (!=)
    while (pos != string::npos) {
        //apply function .push_back(apply function .substr())
        splits.push_back(input_string.substr(i, pos - i));
        //set to calculate
        i = pos + 1;
        //set to apply function .find()
        pos = input_string.find(delimiter, i);
    }
    //apply function .push_back(apply function .substrin(apply function .min(apply function .length)))
    splits.push_back(input_string.substr(i, min(pos, input_string.length()) - i + 1));
    //return
    return splits;
}