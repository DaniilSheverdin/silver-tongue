import { ICheck } from "@/types/Check";
import axios from "axios";
import authHeader from './auth-header';
/**
 * RatingService 
 * Provides UI business logic associated with users rating
 */
export class CheckerService{
	API_URL= process.env.VUE_APP_API_URL;

	public async getResult(text: string) : Promise<ICheck>{
		console.log('checking...:',this.API_URL)
		const storedUser = localStorage.getItem('user');
  	let user = JSON.parse(storedUser ? storedUser : "");
		const config = {
    	headers: { Authorization: `Bearer ${user.token}` }
		};
		const str = JSON.stringify({word:text});
		let result: any = await axios.post(`${this.API_URL}/SS/check`, {'word':`${text}`}, config);
		return result.data;

  }
	public async getArchive() : Promise<ICheck[]>{
		console.log('getting archive...:',this.API_URL)
		const storedUser = localStorage.getItem('user');
  	let user = JSON.parse(storedUser ? storedUser : "");
		const config = {
    	headers: { Authorization: `Bearer ${user.token}` }
		};

		let result: any = await axios.get(`${this.API_URL}/SS/archive`, config);
		return result.data;

  }
}