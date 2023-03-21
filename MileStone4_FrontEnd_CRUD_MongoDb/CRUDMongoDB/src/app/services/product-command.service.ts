import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductCommandService {

  baseUrl = "https://localhost:7158/api/Product";

  constructor(private http:HttpClient) { }

   //delete product by Id
   deleteProduct(id:string):Observable<any>{
    
    return this.http.delete<any>(`${this.baseUrl}/deleteProduct/?id=${id}`);
  }

  //update the product based on id
  updateProduct(product:Product):Observable<any>{
    return this.http.put<any>(`${this.baseUrl}/updateProduct`,product);
  }

  //add product 
  addProduct(product:Product):Observable<any>{
    return this.http.post(`${this.baseUrl}/createProduct`,product);
  }

}
