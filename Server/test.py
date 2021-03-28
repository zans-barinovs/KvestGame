from flask import Flask

app = Flask(__name__)

@app.route('/')
def hello():
    return f"Hello {request.args.get('name', 'world')}"