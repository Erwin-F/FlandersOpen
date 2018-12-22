import React from "react";
import { AppContext } from "./AppContext";
import PropTypes from "prop-types";

class AppProvider extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            ajaxCounter: 0,
            ajaxStarted: () => {
                this.setState({
                    ajaxCounter: this.state.ajaxCounter + 1
                });
            },
            ajaxEnded: () => {
                this.setState({
                    ajaxCounter: this.state.ajaxCounter - 1
                });
            },
            loggingIn: false,
            user: null
        };
    }

    render() {
        return (
            <AppContext.Provider value={this.state}>
                {this.props.children}
            </AppContext.Provider>
        );
    }
}

AppProvider.propTypes = {
    children: PropTypes.object.isRequired
};

export default AppProvider;