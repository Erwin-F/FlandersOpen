import Axios from "axios";
import { authHeader } from '../util/authHeader';

const routePrefix = "api/competition";

const competitionApi = {
    getall(){
        const url = routePrefix;
        return Axios.get(
            url,
            {
                headers: authHeader()
            });
    },
    create(competition){
        const url = routePrefix;
        return Axios.post(
            url,
           competition,
            {
                headers: {
                    'Content-Type': 'application/json'
                }
            });
    },
    update(competition){
        const url = routePrefix + "/" + competition.id;
        return Axios.put(
            url,
           competition,
            {
                headers: {
                    ...authHeader(),
                    'Content-Type': 'application/json'
                }
            });
    },
    delete(competitionId){
        const url = routePrefix + "/" + competitionId;
        return Axios.delete(
            url,
            {
                headers: authHeader()
            });
    }
};

export default competitionApi;