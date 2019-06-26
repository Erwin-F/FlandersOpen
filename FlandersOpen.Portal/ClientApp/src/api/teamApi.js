import Axios from "axios";

const routePrefix = "api/team";

const teamApi = {
    getall(){
        const url = routePrefix;
        return Axios.get(url);
    }
};

export default teamApi;