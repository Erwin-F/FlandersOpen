import React, { Component } from "react";
import { RouteComponentProps } from "react-router";
import { AppContext } from "./common/AppContext";
import AutoBindComponent from "./common/AutobindComponent"

export class AutoBindCounter extends AutoBindComponent {
  constructor(props, context) {
    super(props, context);

    this.state = { currentCount: 0 };

    //this.pageHelper = new LedenaangiftePageHelper(this, 1);
}

handleOnIncrementButton(){
  this.setState({
    currentCount: this.state.currentCount + 1
  });
}

handleOnIncrementAjax(context){
  return function() {
    context.ajaxStarted();
  }
}

  render() {
    return (
      <div>
        <h1>Counter</h1>

        <p>This is a simple example of a React component.</p>

        <p>
          Current count: <strong>{this.state.currentCount}</strong>
        </p>

        <button onClick={this.handleOnIncrementButton}>
          Increment
        </button>

        <AppContext.Consumer>
            {(context) => (
              <button onClick={this.handleOnIncrementAjax(context)}>
                Increment ajax {context.ajaxCounter}
              </button>
            )}
          </AppContext.Consumer>
        
      </div>
    );
  }
}
