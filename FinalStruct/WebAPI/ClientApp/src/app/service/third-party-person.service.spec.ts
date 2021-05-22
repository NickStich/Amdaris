import { TestBed } from '@angular/core/testing';

import { ThirdPartyPersonService } from './third-party-person.service';

describe('ThirdPartyPersonService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ThirdPartyPersonService = TestBed.get(ThirdPartyPersonService);
    expect(service).toBeTruthy();
  });
});
