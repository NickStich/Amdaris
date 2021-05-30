import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from 'src/app/model/product/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private productUrl: string;

  constructor(private http: HttpClient) {
    this.productUrl = 'https://localhost:44380/prod';
  }

  public findAll(): Observable<Product[]> {
    return this.http.get<Product[]>(this.productUrl + '/GetAll');
  }

  public save(product: Product) {
    return this.http.post<Product>(this.productUrl + '/Create', product);
  }

  public update(productId: number, product: Product) {
    return this.http.put(this.productUrl + '/Update/' + productId, product);
  }

  public delete(productId: number) {
    return this.http.delete(this.productUrl + '/Delete/' + productId);
  }

  public getById(productId: number) {
    return this.http.get<Product>(this.productUrl + '/GetById/' + productId);
  }
}
