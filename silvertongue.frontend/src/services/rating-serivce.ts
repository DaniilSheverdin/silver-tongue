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
		let result: any = await axios.get(`${this.API_URL}/user/rating`);
		return result.data;
	}
}