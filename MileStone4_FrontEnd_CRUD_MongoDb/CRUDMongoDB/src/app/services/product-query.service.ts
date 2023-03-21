import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductQueryService {

  baseUrl = "https://localhost:7158/api/Product";

  constructor(private http:HttpClient) { }

  getAllProducts():Observable<any>{
    return this.http.get<any>(`${this.baseUrl}/getAllProducts`);
  }

  getProductById(id:string):Observable<any>{
    return this.http.get<any>(this.baseUrl+`getProductById/?id=${id}`);
  }
}
