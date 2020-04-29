import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IPagination } from '../shared/models/pagination';
import { IProductBrand } from '../shared/models/productBrand';
import { IProductType } from '../shared/models/productType';
import { map } from 'rxjs/operators';
import { ShopParams } from '../shared/models/shopParams';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  baseUrl = 'https://localhost:4000/api/';

  constructor(private http: HttpClient) {}

  getProducts(shopParams: ShopParams) {
    const { brandId, typeId, sort, pageNumber, pageSize } = shopParams;
    let params = new HttpParams();

    if (brandId !== 0) {
      params = params.append('brandId', brandId.toString());
    }
    if (typeId !== 0) {
      params = params.append('typeId', typeId.toString());
    }

    params = params.append('sort', sort);
    params = params.append('pageIndex', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    return this.http
      .get<IPagination>(this.baseUrl + 'products', {
        observe: 'response',
        params,
      })
      .pipe(
        map((response) => {
          return response.body;
        })
      );
  }

  getProductBrands() {
    return this.http.get<IProductBrand[]>(this.baseUrl + 'products/brands');
  }

  getProductTypes() {
    return this.http.get<IProductType[]>(this.baseUrl + 'products/types');
  }
}
