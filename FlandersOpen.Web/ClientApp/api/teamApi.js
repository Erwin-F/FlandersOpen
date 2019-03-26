import Axios from "axios";
import { authHeader } from '../util/authHeader';

const routePrefix = "api/team";

const teamApi = {
    getall(){
        const url = routePrefix;
        return Axios.get(
            url,
            {
                headers: authHeader()
            });
    }
};

export default teamApi;