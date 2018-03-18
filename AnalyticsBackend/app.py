from flask import Flask

import json
import pandas as pd
import requests

def monthlySum( month ):
    import requests
    headers={"Content-Type": "text/json","Authorization": 'DirectLogin token="eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyIiOiIifQ.Tu6PFjCiusFG1ygtQ4nrnnGA2Pb1tk14FVo5LVAchEY"'}
    response=requests.get('https://santander.openbankproject.com/obp/v3.0.0/my/banks/santander.01.uk.sanuk/accounts/9436e58e-dc76-434e-881f-a9442ec46536/transactions',headers=headers) 
    data = json.loads(response.content.decode(response.encoding))


    from pandas.io.json import json_normalize
    df = json_normalize(data['transactions'])
    df['details.value.amount']= df['details.value.amount'].apply(pd.to_numeric)
    df['month'] = df['details.completed'].str.slice(5, 7).apply(pd.to_numeric)

    df1 = df[['details.description','month','details.value.amount','other_account.holder.name',"details.completed"]]  
    if (month!=0):
        df1 = df1[df1["month"]==month]
    earning = df1[df1['details.value.amount'] > 0 ]
    spending =  df1[df1['details.value.amount'] < 0 ]

    json_data = {}
    json_data["spending"] = round(sum(spending["details.value.amount"]),0)
    json_data["earning"] = round(sum(earning["details.value.amount"]),0)

    return json_data

try:
    import flask_jsonpify.jsonify
except:
    from flask.ext.jsonpify import jsonify

app = Flask(__name__)

@app.route("/")
def index():
    return jsonify(foo='bar')

@app.route("/transactions/<month>")
def show_user(month):
    #return jsonify(user={"name":"johnny droptables", "id":user_id})
    return jsonify(monthlySum(int(month)))

@app.route("/transactions")
def list_users():
    return jsonify(monthlySum(0))

if __name__ == "__main__":
    app.run(debug=True)
