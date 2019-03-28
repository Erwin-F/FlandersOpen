
import assign from "object-assign";

export default class RegisterPageHelper {
    constructor(context) {
        this.context = context;
        this.appContext = context.props.appContext;
    }

    register(user) {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(user)
        };

        fetch('/api/user/register', requestOptions).then(this.handleResponse, this.handleError);

        const history = this.context.props.history;
        history.push("/");
    }

    handleResponse(response) {
        return new Promise((resolve, reject) => {
            if (response.ok) {
                // return json if it was returned in the response
                var contentType = response.headers.get("content-type");
                if (contentType && contentType.includes("application/json")) {
                    response.json().then(json => resolve(json));
                } else {
                    resolve();
                }
            } else {
                // return error message from response body
                response.text().then(text => reject(text));
            }
        });
    }

    handleError(error) {
        return Promise.reject(error && error.message);
    }
}