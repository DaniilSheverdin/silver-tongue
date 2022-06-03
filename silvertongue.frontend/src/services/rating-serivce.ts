import { IRating } from "@/types/UserRating";
import axios from "axios";
/**
 * RatingService 
 * Provides UI business logic associated with users rating
 */
export class RatingService{
	API_URL= process.env.VUE_APP_API_URL;

	
	public async getRating() : Promise<IRating[]>{
		console.log('get Rating:',this.API_URL)
		const storedUser = localStorage.getItem('user');
  	let user = JSON.parse(storedUser ? storedUser : "");
		const config = {
    	headers: { Authorization: `Bearer ${user.token}` }
		};
		let result: any = await axios.get(`${this.API_URL}/user/rating`, config);
		return result.data;
	}
}