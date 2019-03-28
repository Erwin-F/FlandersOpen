export default class MenuHelper {
    constructor(context) {
        this.context = context;
    }

    onMenuClick(event, name) {
        this.context.setState({
            activeItem: name
        });

        const history = this.context.props.history;

        switch (name) {
            case "home":
                history.push("/");
                break;
            case "counter":
                history.push("/counter");
                break;
            case "fetchdata":
                history.push("/fetchdata");
                break;
            case "login":
                history.push("/login");
                break;
        }
    }

    onDropdownClick(event, value) {
        this.context.setState({
            activeItem: value
        });

        const history = this.context.props.history;

        switch (value) {
            case "teams":
                history.push("/teams");
                break;
            case "competitions":
                history.push("/competitions");
                break;
            case "users":
                history.push("/users");
                break;
        }
    }

    onLogout(){
        const history = this.context.props.history;
        localStorage.removeItem('user');
        history.push("/");
    }
}