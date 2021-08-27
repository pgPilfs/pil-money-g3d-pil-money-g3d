import { TestBed } from '@angular/core/testing';

import { ScriptServiceService } from './script-service.service';

describe('ScriptServiceService', () => {
  let service: ScriptServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ScriptServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
