import Axios from "axios";
import { authHeader } from '../util/authHeader';

const routePrefix = "api/user";

const userApi = {
    login(username, password) {
        const url = routePrefix + "/authenticate";
        return Axios.post(
            url,             
            {
                username: username,
                password: password
            },
            {
                headers: {
                    'accept': 'application/json'
                }
            });
    },
    getall(){
        const url = routePrefix;
        return Axios.get(
            url,             
            {
                headers: authHeader()
            });
    },
    register(user){
        const url = routePrefix + "/register";
        return Axios.post(
            url,             
           user,
            {
                headers: {
                    'Content-Type': 'application/json'
                }
            });
    },
    update(user){
        const url = routePrefix + "/" + user.id;
        return Axios.put(
            url,             
           user,
            {
                headers: {
                    ...authHeader(),
                    'Content-Type': 'application/json'
                }
            });
    },
    delete(userId){
        const url = routePrefix + "/" + userId;
        return Axios.delete(
            url,             
            {
                headers: authHeader()
            });
    }
};

export default userApi;