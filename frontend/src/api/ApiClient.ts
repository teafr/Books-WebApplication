/* eslint-disable */
/* tslint:disable */
// @ts-nocheck
/*
 * ---------------------------------------------------------------
 * ## THIS FILE WAS GENERATED VIA SWAGGER-TYPESCRIPT-API        ##
 * ##                                                           ##
 * ## AUTHOR: acacode                                           ##
 * ## SOURCE: https://github.com/acacode/swagger-typescript-api ##
 * ---------------------------------------------------------------
 */

/** @format int32 */
export enum Status {
  Value0 = 0,
  Value1 = 1,
  Value2 = 2,
}

/** @format int32 */
export enum Rate {
  Value1 = 1,
  Value2 = 2,
  Value3 = 3,
  Value4 = 4,
  Value5 = 5,
}

export interface AccessTokenResponse {
  tokenType?: string | null;
  accessToken: string | null;
  /** @format int64 */
  expiresIn: number;
  refreshToken: string | null;
}

export interface ApplicationUser {
  id?: string | null;
  userName?: string | null;
  normalizedUserName?: string | null;
  email?: string | null;
  normalizedEmail?: string | null;
  emailConfirmed?: boolean;
  passwordHash?: string | null;
  securityStamp?: string | null;
  concurrencyStamp?: string | null;
  phoneNumber?: string | null;
  phoneNumberConfirmed?: boolean;
  twoFactorEnabled?: boolean;
  /** @format date-time */
  lockoutEnd?: string | null;
  lockoutEnabled?: boolean;
  /** @format int32 */
  accessFailedCount?: number;
  name?: string | null;
  savedBooks?: SavedBookEntity[] | null;
}

export interface ForgotPasswordRequest {
  email: string | null;
}

export interface HttpValidationProblemDetails {
  type?: string | null;
  title?: string | null;
  /** @format int32 */
  status?: number | null;
  detail?: string | null;
  instance?: string | null;
  errors?: Record<string, string[]>;
  [key: string]: any;
}

export interface InfoRequest {
  newEmail?: string | null;
  newPassword?: string | null;
  oldPassword?: string | null;
}

export interface InfoResponse {
  email: string | null;
  isEmailConfirmed: boolean;
}

export interface LoginRequest {
  email: string | null;
  password: string | null;
  twoFactorCode?: string | null;
  twoFactorRecoveryCode?: string | null;
}

export interface ProblemDetails {
  type?: string | null;
  title?: string | null;
  /** @format int32 */
  status?: number | null;
  detail?: string | null;
  instance?: string | null;
  [key: string]: any;
}

export interface RefreshRequest {
  refreshToken: string | null;
}

export interface RegisterRequest {
  email: string | null;
  password: string | null;
}

export interface ResendConfirmationEmailRequest {
  email: string | null;
}

export interface ResetPasswordRequest {
  email: string | null;
  resetCode: string | null;
  newPassword: string | null;
}

export interface ReviewModel {
  /** @format int32 */
  id?: number;
  text?: string | null;
  rating: Rate;
  /** @format date-time */
  reviewDate: string;
  /**
   * @minLength 36
   * @maxLength 36
   */
  reviewerId: string;
}

export interface SavedBookEntity {
  userId?: string | null;
  /** @format int32 */
  bookId?: number;
  status?: Status;
  user?: ApplicationUser;
}

export interface TwoFactorRequest {
  enable?: boolean | null;
  twoFactorCode?: string | null;
  resetSharedKey?: boolean;
  resetRecoveryCodes?: boolean;
  forgetMachine?: boolean;
}

export interface TwoFactorResponse {
  sharedKey: string | null;
  /** @format int32 */
  recoveryCodesLeft: number;
  recoveryCodes?: string[] | null;
  isTwoFactorEnabled: boolean;
  isMachineRemembered: boolean;
}

export type QueryParamsType = Record<string | number, any>;
export type ResponseFormat = keyof Omit<Body, "body" | "bodyUsed">;

export interface FullRequestParams extends Omit<RequestInit, "body"> {
  /** set parameter to `true` for call `securityWorker` for this request */
  secure?: boolean;
  /** request path */
  path: string;
  /** content type of request body */
  type?: ContentType;
  /** query params */
  query?: QueryParamsType;
  /** format of response (i.e. response.json() -> format: "json") */
  format?: ResponseFormat;
  /** request body */
  body?: unknown;
  /** base url */
  baseUrl?: string;
  /** request cancellation token */
  cancelToken?: CancelToken;
}

export type RequestParams = Omit<
  FullRequestParams,
  "body" | "method" | "query" | "path"
>;

export interface ApiConfig<SecurityDataType = unknown> {
  baseUrl?: string;
  baseApiParams?: Omit<RequestParams, "baseUrl" | "cancelToken" | "signal">;
  securityWorker?: (
    securityData: SecurityDataType | null,
  ) => Promise<RequestParams | void> | RequestParams | void;
  customFetch?: typeof fetch;
}

export interface HttpResponse<D extends unknown, E extends unknown = unknown>
  extends Response {
  data: D;
  error: E;
}

type CancelToken = Symbol | string | number;

export enum ContentType {
  Json = "application/json",
  JsonApi = "application/vnd.api+json",
  FormData = "multipart/form-data",
  UrlEncoded = "application/x-www-form-urlencoded",
  Text = "text/plain",
}

export class HttpClient<SecurityDataType = unknown> {
  public baseUrl: string = "";
  private securityData: SecurityDataType | null = null;
  private securityWorker?: ApiConfig<SecurityDataType>["securityWorker"];
  private abortControllers = new Map<CancelToken, AbortController>();
  private customFetch = (...fetchParams: Parameters<typeof fetch>) =>
    fetch(...fetchParams);

  private baseApiParams: RequestParams = {
    credentials: "same-origin",
    headers: {},
    redirect: "follow",
    referrerPolicy: "no-referrer",
  };

  constructor(apiConfig: ApiConfig<SecurityDataType> = {}) {
    Object.assign(this, apiConfig);
  }

  public setSecurityData = (data: SecurityDataType | null) => {
    this.securityData = data;
  };

  protected encodeQueryParam(key: string, value: any) {
    const encodedKey = encodeURIComponent(key);
    return `${encodedKey}=${encodeURIComponent(typeof value === "number" ? value : `${value}`)}`;
  }

  protected addQueryParam(query: QueryParamsType, key: string) {
    return this.encodeQueryParam(key, query[key]);
  }

  protected addArrayQueryParam(query: QueryParamsType, key: string) {
    const value = query[key];
    return value.map((v: any) => this.encodeQueryParam(key, v)).join("&");
  }

  protected toQueryString(rawQuery?: QueryParamsType): string {
    const query = rawQuery || {};
    const keys = Object.keys(query).filter(
      (key) => "undefined" !== typeof query[key],
    );
    return keys
      .map((key) =>
        Array.isArray(query[key])
          ? this.addArrayQueryParam(query, key)
          : this.addQueryParam(query, key),
      )
      .join("&");
  }

  protected addQueryParams(rawQuery?: QueryParamsType): string {
    const queryString = this.toQueryString(rawQuery);
    return queryString ? `?${queryString}` : "";
  }

  private contentFormatters: Record<ContentType, (input: any) => any> = {
    [ContentType.Json]: (input: any) =>
      input !== null && (typeof input === "object" || typeof input === "string")
        ? JSON.stringify(input)
        : input,
    [ContentType.JsonApi]: (input: any) =>
      input !== null && (typeof input === "object" || typeof input === "string")
        ? JSON.stringify(input)
        : input,
    [ContentType.Text]: (input: any) =>
      input !== null && typeof input !== "string"
        ? JSON.stringify(input)
        : input,
    [ContentType.FormData]: (input: any) => {
      if (input instanceof FormData) {
        return input;
      }

      return Object.keys(input || {}).reduce((formData, key) => {
        const property = input[key];
        formData.append(
          key,
          property instanceof Blob
            ? property
            : typeof property === "object" && property !== null
              ? JSON.stringify(property)
              : `${property}`,
        );
        return formData;
      }, new FormData());
    },
    [ContentType.UrlEncoded]: (input: any) => this.toQueryString(input),
  };

  protected mergeRequestParams(
    params1: RequestParams,
    params2?: RequestParams,
  ): RequestParams {
    return {
      ...this.baseApiParams,
      ...params1,
      ...(params2 || {}),
      headers: {
        ...(this.baseApiParams.headers || {}),
        ...(params1.headers || {}),
        ...((params2 && params2.headers) || {}),
      },
    };
  }

  protected createAbortSignal = (
    cancelToken: CancelToken,
  ): AbortSignal | undefined => {
    if (this.abortControllers.has(cancelToken)) {
      const abortController = this.abortControllers.get(cancelToken);
      if (abortController) {
        return abortController.signal;
      }
      return void 0;
    }

    const abortController = new AbortController();
    this.abortControllers.set(cancelToken, abortController);
    return abortController.signal;
  };

  public abortRequest = (cancelToken: CancelToken) => {
    const abortController = this.abortControllers.get(cancelToken);

    if (abortController) {
      abortController.abort();
      this.abortControllers.delete(cancelToken);
    }
  };

  public request = async <T = any, E = any>({
    body,
    secure,
    path,
    type,
    query,
    format,
    baseUrl,
    cancelToken,
    ...params
  }: FullRequestParams): Promise<HttpResponse<T, E>> => {
    const secureParams =
      ((typeof secure === "boolean" ? secure : this.baseApiParams.secure) &&
        this.securityWorker &&
        (await this.securityWorker(this.securityData))) ||
      {};
    const requestParams = this.mergeRequestParams(params, secureParams);
    const queryString = query && this.toQueryString(query);
    const payloadFormatter = this.contentFormatters[type || ContentType.Json];
    const responseFormat = format || requestParams.format;

    return this.customFetch(
      `${baseUrl || this.baseUrl || ""}${path}${queryString ? `?${queryString}` : ""}`,
      {
        ...requestParams,
        headers: {
          ...(requestParams.headers || {}),
          ...(type && type !== ContentType.FormData
            ? { "Content-Type": type }
            : {}),
        },
        signal:
          (cancelToken
            ? this.createAbortSignal(cancelToken)
            : requestParams.signal) || null,
        body:
          typeof body === "undefined" || body === null
            ? null
            : payloadFormatter(body),
      },
    ).then(async (response) => {
      const r = response.clone() as HttpResponse<T, E>;
      r.data = null as unknown as T;
      r.error = null as unknown as E;

      const data = !responseFormat
        ? r
        : await response[responseFormat]()
            .then((data) => {
              if (r.ok) {
                r.data = data;
              } else {
                r.error = data;
              }
              return r;
            })
            .catch((e) => {
              r.error = e;
              return r;
            });

      if (cancelToken) {
        this.abortControllers.delete(cancelToken);
      }

      if (!response.ok) throw data;
      return data;
    });
  };
}

/**
 * @title booksAPI
 * @version 1.0
 */
export class Api<
  SecurityDataType extends unknown,
> extends HttpClient<SecurityDataType> {
  api = {
    /**
     * No description
     *
     * @tags Books
     * @name BooksDetail
     * @request GET:/api/Books/{id}
     */
    booksDetail: (id: number, params: RequestParams = {}) =>
      this.request<void, ProblemDetails>({
        path: `/api/Books/${id}`,
        method: "GET",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Books
     * @name BooksTextList
     * @request GET:/api/Books/{id}/text
     */
    booksTextList: (id: number, params: RequestParams = {}) =>
      this.request<void, ProblemDetails>({
        path: `/api/Books/${id}/text`,
        method: "GET",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Books
     * @name BooksReviewsList
     * @request GET:/api/Books/{id}/reviews
     */
    booksReviewsList: (id: number, params: RequestParams = {}) =>
      this.request<void, any>({
        path: `/api/Books/${id}/reviews`,
        method: "GET",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Reviews
     * @name ReviewsList
     * @request GET:/api/Reviews
     */
    reviewsList: (params: RequestParams = {}) =>
      this.request<void, any>({
        path: `/api/Reviews`,
        method: "GET",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Reviews
     * @name ReviewsDetail
     * @request GET:/api/Reviews/{id}
     */
    reviewsDetail: (id: number, params: RequestParams = {}) =>
      this.request<void, ProblemDetails>({
        path: `/api/Reviews/${id}`,
        method: "GET",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Reviews
     * @name ReviewsUpdate
     * @request PUT:/api/Reviews/{id}
     */
    reviewsUpdate: (
      id: number,
      data: ReviewModel,
      params: RequestParams = {},
    ) =>
      this.request<void, ProblemDetails>({
        path: `/api/Reviews/${id}`,
        method: "PUT",
        body: data,
        type: ContentType.Json,
        ...params,
      }),

    /**
     * No description
     *
     * @tags Reviews
     * @name ReviewsDelete
     * @request DELETE:/api/Reviews/{id}
     */
    reviewsDelete: (id: number, params: RequestParams = {}) =>
      this.request<void, ProblemDetails>({
        path: `/api/Reviews/${id}`,
        method: "DELETE",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Reviews
     * @name ReviewsBookCreate
     * @request POST:/api/Reviews/book/{bookId}
     */
    reviewsBookCreate: (
      bookId: number,
      data: ReviewModel,
      params: RequestParams = {},
    ) =>
      this.request<void, ProblemDetails>({
        path: `/api/Reviews/book/${bookId}`,
        method: "POST",
        body: data,
        type: ContentType.Json,
        ...params,
      }),

    /**
     * No description
     *
     * @tags Users
     * @name UsersDetail
     * @request GET:/api/Users/{id}
     */
    usersDetail: (id: string, params: RequestParams = {}) =>
      this.request<void, ProblemDetails>({
        path: `/api/Users/${id}`,
        method: "GET",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Users
     * @name UsersSavedBooksDetail
     * @request GET:/api/Users/{id}/savedBooks/{status}
     */
    usersSavedBooksDetail: (
      id: string,
      status: number,
      params: RequestParams = {},
    ) =>
      this.request<void, any>({
        path: `/api/Users/${id}/savedBooks/${status}`,
        method: "GET",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Users
     * @name UsersReviewsList
     * @request GET:/api/Users/{id}/reviews
     */
    usersReviewsList: (id: string, params: RequestParams = {}) =>
      this.request<void, any>({
        path: `/api/Users/${id}/reviews`,
        method: "GET",
        ...params,
      }),
  };
  user = {
    /**
     * No description
     *
     * @tags booksAPI
     * @name GetUser
     * @request GET:/user/me
     */
    getUser: (params: RequestParams = {}) =>
      this.request<ApplicationUser, any>({
        path: `/user/me`,
        method: "GET",
        format: "json",
        ...params,
      }),
  };
  logout = {
    /**
     * No description
     *
     * @tags booksAPI
     * @name LogoutCreate
     * @request POST:/logout
     */
    logoutCreate: (params: RequestParams = {}) =>
      this.request<void, any>({
        path: `/logout`,
        method: "POST",
        ...params,
      }),
  };
  register = {
    /**
     * No description
     *
     * @tags booksAPI
     * @name RegisterCreate
     * @request POST:/register
     */
    registerCreate: (data: RegisterRequest, params: RequestParams = {}) =>
      this.request<void, HttpValidationProblemDetails>({
        path: `/register`,
        method: "POST",
        body: data,
        type: ContentType.Json,
        ...params,
      }),
  };
  login = {
    /**
     * No description
     *
     * @tags booksAPI
     * @name LoginCreate
     * @request POST:/login
     */
    loginCreate: (
      data: LoginRequest,
      query?: {
        useCookies?: boolean;
        useSessionCookies?: boolean;
      },
      params: RequestParams = {},
    ) =>
      this.request<AccessTokenResponse, any>({
        path: `/login`,
        method: "POST",
        query: query,
        body: data,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),
  };
  refresh = {
    /**
     * No description
     *
     * @tags booksAPI
     * @name RefreshCreate
     * @request POST:/refresh
     */
    refreshCreate: (data: RefreshRequest, params: RequestParams = {}) =>
      this.request<AccessTokenResponse, any>({
        path: `/refresh`,
        method: "POST",
        body: data,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),
  };
  confirmEmail = {
    /**
     * No description
     *
     * @tags booksAPI
     * @name MapIdentityApiConfirmEmail
     * @request GET:/confirmEmail
     */
    mapIdentityApiConfirmEmail: (
      query?: {
        userId?: string;
        code?: string;
        changedEmail?: string;
      },
      params: RequestParams = {},
    ) =>
      this.request<void, any>({
        path: `/confirmEmail`,
        method: "GET",
        query: query,
        ...params,
      }),
  };
  resendConfirmationEmail = {
    /**
     * No description
     *
     * @tags booksAPI
     * @name ResendConfirmationEmailCreate
     * @request POST:/resendConfirmationEmail
     */
    resendConfirmationEmailCreate: (
      data: ResendConfirmationEmailRequest,
      params: RequestParams = {},
    ) =>
      this.request<void, any>({
        path: `/resendConfirmationEmail`,
        method: "POST",
        body: data,
        type: ContentType.Json,
        ...params,
      }),
  };
  forgotPassword = {
    /**
     * No description
     *
     * @tags booksAPI
     * @name ForgotPasswordCreate
     * @request POST:/forgotPassword
     */
    forgotPasswordCreate: (
      data: ForgotPasswordRequest,
      params: RequestParams = {},
    ) =>
      this.request<void, HttpValidationProblemDetails>({
        path: `/forgotPassword`,
        method: "POST",
        body: data,
        type: ContentType.Json,
        ...params,
      }),
  };
  resetPassword = {
    /**
     * No description
     *
     * @tags booksAPI
     * @name ResetPasswordCreate
     * @request POST:/resetPassword
     */
    resetPasswordCreate: (
      data: ResetPasswordRequest,
      params: RequestParams = {},
    ) =>
      this.request<void, HttpValidationProblemDetails>({
        path: `/resetPassword`,
        method: "POST",
        body: data,
        type: ContentType.Json,
        ...params,
      }),
  };
  manage = {
    /**
     * No description
     *
     * @tags booksAPI
     * @name PostManage
     * @request POST:/manage/2fa
     */
    postManage: (data: TwoFactorRequest, params: RequestParams = {}) =>
      this.request<TwoFactorResponse, HttpValidationProblemDetails | void>({
        path: `/manage/2fa`,
        method: "POST",
        body: data,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags booksAPI
     * @name InfoList
     * @request GET:/manage/info
     */
    infoList: (params: RequestParams = {}) =>
      this.request<InfoResponse, HttpValidationProblemDetails | void>({
        path: `/manage/info`,
        method: "GET",
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags booksAPI
     * @name InfoCreate
     * @request POST:/manage/info
     */
    infoCreate: (data: InfoRequest, params: RequestParams = {}) =>
      this.request<InfoResponse, HttpValidationProblemDetails | void>({
        path: `/manage/info`,
        method: "POST",
        body: data,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),
  };
}
