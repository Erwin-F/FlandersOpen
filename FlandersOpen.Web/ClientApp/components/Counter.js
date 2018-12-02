import React, { Component } from "react";
import { RouteComponentProps } from "react-router";
import { AppContext } from "./common/AppContext";

export class Counter extends Component {
  state = { currentCount: 0 };

  incrementCounter() {
    this.setState({
      currentCount: this.state.currentCount + 1
    });
  }

  render() {
    return (
      <div>
        <h1>Counter</h1>

        <p>This is a simple example of a React component.</p>

        <p>
          Current count: <strong>{this.state.currentCount}</strong>
        </p>

        <button
          onClick={() => {
            this.incrementCounter();
          }}
        >
          Increment
        </button>

        <AppContext.Consumer>
            {(context) => (
              <button onClick={() => {context.ajaxStarted()}}>
                Increment ajax {context.ajaxCounter}
              </button>
            )}
          </AppContext.Consumer>
        
      </div>
    );
  }
}
